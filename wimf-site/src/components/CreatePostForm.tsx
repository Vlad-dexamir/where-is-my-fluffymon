import React, {useState} from "react";
import Form from 'react-bootstrap/Form';
import {Context} from "../Context";
import {CreatePostPayload, PostType} from "../core/domain/Post/Post";
import {Button} from "./elements/Button/Button";


export const CreatePostForm: React.FC = () => {
    const [title, updateTitle] = useState('');
    const [content, updateContent] = useState('');
    const [reward, updateReward] = useState(0);
    const [postType, updatePostType] = useState('');

    const createPost = async() => {
        console.log(title, content, reward, postType);
        if(!title && !content && !reward && !postType) {
            await Context.alertService.fire({
                icon: 'error',
                title: 'Ooops....',
                text: 'Your post is not valid, please complete all fields',
                showCloseButton: true,
                showConfirmButton: true,
            })
            return;
        }

        const payload: CreatePostPayload = {
            title,
            content,
            reward,
            userId: 'test-userId',
            postType: postType as PostType,
            location: {
                lat: 111223,
                lng: 3243434,
            }
        };

        try {
            const response = await Context.apiService.createPost(payload);

            if(response) {
                await Context.alertService.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Post created successfully',
                });
            }

        } catch (e) {
            console.error(e);
            await Context.alertService.fire({
                icon: 'error',
                title: 'Oops...',
                text: e.message,
            });
        }
    }
    return(
    <Form>
        <Form.Group>
         <Form.Label>Post Type</Form.Label>
            <Form.Control
                as="select"
                aria-label="Select Post Type"
                name="postType"
                placeholder="Select Post Type"
                onChange={(e)=> updatePostType(e.target.value)}
            >
                <option value="Found">Found</option>
                <option value="Lost">Lost</option>
                <option value="Spotted">Spotted</option>
            </Form.Control>
        </Form.Group>
        <Form.Group>
            <Form.Label>Post Title</Form.Label>
            <Form.Control
                type="text"
                placeholder="Insert the title of the announcement here "
                name="title"
                required
                onChange={(e) => updateTitle(e.target.value)}
            />
        </Form.Group>
        <Form.Group>
            <Form.Label>Post Description</Form.Label>
            <Form.Control
                as="textarea"
                placeholder="Write a description"
                name="content"
                required
                onChange={(e) => updateContent(e.target.value)}
            />
        </Form.Group>
        <Form.Group>
            <Form.Label>Reward</Form.Label>
            <Form.Control
                type="number"
                placeholder="Reward(e.g. 25)"
                required
                onChange={(e) => updateReward(parseInt(e.target.value || ''))}
            />
        </Form.Group>
        <Form.Group>
            <Form.Label>Attachements</Form.Label>
                <Form.File id="exampleFormControlFile1" />
        </Form.Group>
            <Button type="button" handleClick={createPost}>Create</Button>
    </Form>
    );
}
