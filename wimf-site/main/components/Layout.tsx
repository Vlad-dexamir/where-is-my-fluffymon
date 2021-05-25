import React from 'react';
import {GlobalStyle} from '../globalStyle';

type LayoutProps = {
    children: React.ReactNode;
}

export const Layout: React.FC<LayoutProps> = ({children})=> (
    <>
    <GlobalStyle/>
        <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css2?family=Merriweather&display=swap"
        />
        <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css2?family=Roboto+Condensed%20SC&display=swap"
        />
        <link href="https://fonts.googleapis.com/css2?family=Amatic+SC&display=swap" rel="stylesheet"/>
        <link href="https://fonts.googleapis.com/css2?family=Train+One&display=swap" rel="stylesheet"/>
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

        <main id="content">{children}</main>
        <footer>
        </footer>
    </>
)
