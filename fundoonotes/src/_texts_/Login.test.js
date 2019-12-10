import React from 'react';
import { shallow } from 'enzyme';
import LoginComponent from '../Components/LoginComponent'
// import '../setUpTest'
const Enzyme = require('enzyme');
// this is where we reference the adapter package we installed
// earlier
const EnzymeAdapter = require('enzyme-adapter-react-16');
// This sets up the adapter to be used by Enzyme
Enzyme.configure({ adapter: new EnzymeAdapter() });

describe('Login Component', () => {

    it('Test  without throwing an error', () => {
        expect(shallow(< LoginComponent />).exists()).toBe(true)
    })

    it('Test an email input', () => {
        expect(shallow(< LoginComponent />).find('#emailId').length).toEqual(1)
    })
    it('Test a password input', () => {
        expect(shallow(< LoginComponent />).find('#password').length).toEqual(1)
    })
    describe('Email input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< LoginComponent />);
            wrapper.find('#emailId').simulate('change',
                {
                    target: {
                        name: 'emailId',
                        value: 'deepumaurya07@gmail.com'
                    }
                });
            expect(wrapper.state('emailId')).toEqual('deepumaurya07@gmail.com');
        })
    })
    
    
    describe('Test Password input', () => {
        it('should respond to change event and change the state of the Login Component',() => {
                const wrapper = shallow(< LoginComponent />);
                wrapper.find('#password').simulate('change',
                    {
                        target:
                        {
                            name: 'password',
                            value: '987654321'
                        }
                    });
                expect(wrapper.state('password')).toEqual('987654321');
            })
    })
})