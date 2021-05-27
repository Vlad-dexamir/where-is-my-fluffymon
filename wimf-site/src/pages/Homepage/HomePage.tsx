import React from "react";
import {SearchPostResponse} from "../../core/domain/Post/SearchPostResponse";
import {SearchPostRequest} from "../../core/domain/Post/SearchPostRequest";
import {Context} from "../../Context";
import {HomePageContainer} from "./HomePageStyles";
import {Posts} from "../../components/Posts";
import {LoadingSpinner} from "../../components/LoadingSpinner/LoadingSpinner";
import MapContainer from '../../components/Map/MapContainer';

interface HomePageState {
    searchPostResponse: SearchPostResponse;
    searchRequest: SearchPostRequest;
    isLoading: boolean;
}

export class HomePage extends React.Component<{}, HomePageState> {
    constructor(props: any) {
        super(props);
        this.state = {
            searchPostResponse : {
                total: 0,
                posts: [],
            },
            searchRequest: SearchPostRequest.create({size: 10}),
            isLoading: false,
        }
    }

    async componentDidMount() {
        this.setState({isLoading: true});


        const response = await Context.apiService.searchPost(this.state.searchRequest);

        this.setState({
            searchPostResponse: response,
            isLoading: false,
        });
    }

    render() {
        const {total, posts} = this.state.searchPostResponse;

        if(this.state.isLoading) {
            return <LoadingSpinner/>
        }

        return (
            <HomePageContainer>
                <MapContainer />
                {total > 0 && posts.length > 0 && (
                    <Posts posts={posts} />
                )}
            </HomePageContainer>
        )
    }
}
