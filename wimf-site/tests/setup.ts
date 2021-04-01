import * as Enzyme from 'enzyme';
import * as Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() });
// @ts-ignore
Date.now() = jest.fn(() => 1617176465) //Wed Mar 31 2021 10:41:05 GMT+0300


// @ts-ignore
window.matchMedia =
    window.matchMedia ||
    (() => {
        return {
            matches: true,
            addListener: () => null,
            removeListener: () => null,
        };
    });

// @ts-ignore
window.requestAnimationFrame =
    window.requestAnimationFrame ||
    ((callback) => {
        setTimeout(callback, 0);
    });

window.scroll = jest.fn();

window.URL.createObjectURL = jest.fn();