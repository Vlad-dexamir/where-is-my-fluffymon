import React from "react";
import  {Card, Button} from "react-bootstrap";
import {PostComponentsProps} from "../../core/domain/Post/PostComponenetsProps";
import cardBannerImg from '../../mocks/images/info.jpg';

export const PostCard: React.FC<PostComponentsProps> = ({post}) => {
    const {title, content, reward} = post;

    const truncContent = () => content.length > 130 ? content.slice(0, 65).concat('...') : content;

    return(
        <Card className="animated fadeInUp card">
            <Card.Img src={cardBannerImg} className="cardImg" variant="top" />
            <Card.Body>
                <Card.Title className="titlePost">{title}</Card.Title>
                <Card.Text className="desc">{truncContent()}</Card.Text>
                <Button className="float-right post-card-button buttonPost">
                    See more
                </Button>
            </Card.Body>
            {reward && <Card.Footer className="text-muted">Reward: {reward}</Card.Footer>}
        </Card>
    );
}
