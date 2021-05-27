import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useEffect, useRef, useState } from 'react';

import {
  Navigation as StyledNavigation,
  NavigationItem,
  Logo,
  NavButton,
  NavList,
  NavListContent,
} from './NavigationBarStyles';

import {WimfLogo} from "../elements/WimfLogo/WimfLogo";
import {Context} from "../../Context";
import {Button} from "../elements/Button/Button";
import {ModalBox} from "../elements/Modal";
import {CreatePostForm} from "../CreatePostForm";

export const navItems = [
  {
    label: 'Top Posts',
    linkAs: `${Context.BASE_PATH}/top-posts`,
    link: `${Context.BASE_PATH}/top-posts`,
  },
  {
    label: 'Trending',
    link: `${Context.BASE_PATH}/trending`,
    linkAs: `${Context.BASE_PATH}/trending`,
  },
  {
    label: 'Most Recent',
    link: `${Context.BASE_PATH}/most-recent`,
    linkAs: `${Context.BASE_PATH}/most-recent`,
  },
];

const useOnClickOutside = (ref: any, handler: any, exclude: any) => {
  useEffect(() => {
    const listener = (event: Event) => {
      if (
        !ref.current ||
        ref.current.contains(event.target) ||
        (exclude && exclude.current && exclude.current.contains(event.target))
      ) {
        return;
      }
      handler();
    };

    document.addEventListener('mousedown', listener);
    document.addEventListener('touchend', listener);

    return () => {
      document.removeEventListener('mousedown', listener);
      document.removeEventListener('touchend', listener);
    };
  }, [ref, handler]);
};

const useScroll = (ref: any) => {
  useEffect(() => {
    const listener = (e: Event) => {
      const target: HTMLElement = e.target as HTMLElement;
      const newPosition =
        (target && target.scrollTop) ||
        window.scrollY ||
        (document &&
          document.documentElement &&
          document.documentElement.scrollTop);

      if (newPosition > 100) {
        ref.current.classList.add('scrolling-nav');
      } else {
        ref.current.classList.remove('scrolling-nav');
      }
    };

    window.addEventListener('scroll', listener);
    return () => {
      window.removeEventListener('scroll', listener);
    };
  }, [ref]);
};

export const Navigation: React.FC = () => {
  const navNode = useRef<HTMLDivElement>(null);
  const [menuToggle, setMenuToggle] = useState<boolean>(false);
  const [isModalOpen, setModalOpen] = useState<boolean>(false);

  useOnClickOutside(navNode, () => setMenuToggle(false), null);

  useScroll(navNode);

  const onSetMenuToggleClick = () => {
    setMenuToggle(!menuToggle);
  };

  return (
    <StyledNavigation ref={navNode} className="qa-automation-navigation">
      <ModalBox isOpen={isModalOpen} title="Create a post" handleClose={()=>setModalOpen(false)}>
        <CreatePostForm />
      </ModalBox>
      <NavButton onClick={() => onSetMenuToggleClick()}>
        <FontAwesomeIcon icon={faBars} size="1x" />
      </NavButton>
      <a
        href={`${Context.BASE_PATH}/`}
      >
        <a>
          <Logo>
            <WimfLogo />
          </Logo>
        </a>
      </a>
      <NavList
        onMouseDown={(e) => {
          e.preventDefault();
          e.stopPropagation();
          e.nativeEvent.stopImmediatePropagation();
        }}
        className={menuToggle ? 'toggled' : undefined}
      >
        <NavListContent>
          {navItems.map((item) => (
            <a
              href={item.link}
              key={`${item.label.toLowerCase()}-navigation-bar`}
            >
              <NavigationItem
                className={
                 window.location.pathname.includes(item.linkAs.toLowerCase())
                    ? 'active'
                    : ''
                }
              >
                {item.label}
              </NavigationItem>
            </a>
          ))}
        </NavListContent>
        <Button
            type="button"
            handleClick={()=> setModalOpen(true)}
        >
          Create Post
        </Button>
      </NavList>
    </StyledNavigation>
  );
};
