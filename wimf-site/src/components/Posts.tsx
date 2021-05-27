import React from "react";
import {Post} from "../core/domain/Post/Post";
import {Col, Container, Row} from "react-bootstrap";
import {PostCard} from "./Post/PostCard";

interface PostsProps {
    posts : Post[];
}

export const Posts: React.FC<PostsProps> = ({posts}) => (
    <Container className="mainPosts">
        <Row>
            {posts.map((post, index) =>
                <Col>
                    <PostCard post={post} key={`post_${index}`} />
                </Col>
            )}
        </Row>
    </Container>
)

