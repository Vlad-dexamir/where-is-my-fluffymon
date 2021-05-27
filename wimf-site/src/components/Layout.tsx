import React from 'react';
import { GlobalStyle } from '../globalStyle';
import {Navigation} from "./NavigationBar/NavigationBar";

type LayoutProps = {
    children: React.ReactNode;
    hideHeader?: boolean;
};

export const Layout: React.FC<LayoutProps> = ({ children, hideHeader }) => (
    <>
        <GlobalStyle />
        <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css2?family=Merriweather&display=swap"
        />
        <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css2?family=Roboto+Condensed%20SC&display=swap"
        />
        <link
            href="https://fonts.googleapis.com/css2?family=Amatic+SC&display=swap"
            rel="stylesheet"
        />
        <link
            href="https://fonts.googleapis.com/css2?family=Train+One&display=swap"
            rel="stylesheet"
        />
        <link
            rel="stylesheet"
            type="text/css"
            charSet="UTF-8"
            href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.min.css"
        />
        <link
            rel="stylesheet"
            type="text/css"
            href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick-theme.min.css"
        />

        <link
            rel="stylesheet"
            href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"
            integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l"
            crossOrigin="anonymous"
        />
            {!hideHeader && (
                <Navigation />
            )}
        <main id="content">{children}</main>
        <footer></footer>
    </>
);
