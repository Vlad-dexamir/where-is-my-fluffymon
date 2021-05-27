import React from 'react';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faChevronRight,
  faChevronLeft,
} from '@fortawesome/free-solid-svg-icons';
import Carousel, { ResponsiveType } from 'react-multi-carousel';
import { ButtonGroupProps } from 'react-multi-carousel/lib/types';
import { ArrowBtnTrays } from './SliderStyles';

interface SliderProps {
  cards: JSX.Element[];
  responsive?: ResponsiveType;
  draggable?: boolean;
  swipeable?: boolean;
  showDots?: boolean;
  customButtonGroup?: JSX.Element;
  arrows?: boolean;
  renderButtonGroupOutside?: boolean;
  keyBoardControl?: boolean;
  autoPlaySpeed?: number;
}

interface ArrowFace {
  right?: boolean;
  onClick?: (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void;
}

const Arrow = ({ right, onClick }: ArrowFace) => {
  const onArrowClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    onClick!(e);
  };

  return (
    <ArrowBtnTrays alignToRight={right} onClick={onArrowClick}>
      <FontAwesomeIcon icon={right ? faChevronRight : faChevronLeft} />
    </ArrowBtnTrays>
  );
};

const ButtonGroup = ({ next, previous, carouselState }: ButtonGroupProps) => {
  const currentSlide = carouselState!.currentSlide;
  const totalItems = carouselState!.totalItems;
  const slidesToShow = carouselState!.slidesToShow;
  const showRightArrow = !(currentSlide + slidesToShow >= totalItems);

  return (
    <>
      {currentSlide !== 0 && previous && <Arrow onClick={() => previous()} />}
      {showRightArrow && next && <Arrow right={true} onClick={() => next()} />}
    </>
  );
};

export const Slider: React.FC<SliderProps> = (props: SliderProps) => {
  const {
    responsive,
    cards,
    swipeable = false,
    draggable = false,
    showDots = false,
    customButtonGroup = <ButtonGroup />,
    arrows = false,
    renderButtonGroupOutside = true,
    keyBoardControl = false,
    autoPlaySpeed = 1000,
  } = props;

  const defaultResponsive: ResponsiveType = {
    desktop: {
      breakpoint: { max: 3000, min: 1023 },
      items: 4,
      slidesToSlide: 4,
    },
    tablet: {
      breakpoint: { max: 1023, min: 464 },
      items: 3,
      slidesToSlide: 3,
    },
    mobile: {
      breakpoint: { max: 464, min: 0 },
      items: 1,
      slidesToSlide: 1,
    },
  };

  const carouselSettings = {
    swipeable,
    draggable,
    showDots,
    ssr: true, // server side rendering for carousel
    autoPlaySpeed,
    keyBoardControl,
    arrows,
    removeArrowOnDeviceType: ['mobile'],
    renderButtonGroupOutside,
    customButtonGroup,
    responsive: responsive ? responsive : defaultResponsive,
  };

  return (
    <Carousel {...carouselSettings}>
      {cards && cards.map((card: JSX.Element) => card)}
    </Carousel>
  );
};
