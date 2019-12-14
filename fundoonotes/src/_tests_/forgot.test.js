import React from 'react';
import { shallow } from 'enzyme';
// import Forgot from '../';
import ForgotComponent from '../Components/ForgotComponent'
const Enzyme = require('enzyme');
const EnzymeAdapter = require('enzyme-adapter-react-16');
Enzyme.configure({ adapter: new EnzymeAdapter() });
describe('forgot Component', () => {
    it('Test  without throwing an error', () => {
        expect(shallow(< ForgotComponent />).exists()).toBe(true)
    })
    it('Test an email input', () => {
        expect(shallow(< ForgotComponent />).find('#email').length).toEqual(1)
    })
    describe('Email input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< ForgotComponent />);
            wrapper.find('#email').simulate('change',
                {
                    target: {
                        name: 'emailId',
                        value: 'rr582619@gmail.com'
                    }
                });
            expect(wrapper.state('emailId')).toEqual('rr582619@gmail.com');
        })
    })
})