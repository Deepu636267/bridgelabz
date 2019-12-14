import React from 'react';
import { shallow } from 'enzyme';
import RegistrationComponent from '../Components/RegistrationComponent';
// import '../setUpTest'
const Enzyme = require('enzyme');
// this is where we reference the adapter package we installed
// earlier
const EnzymeAdapter = require('enzyme-adapter-react-16');
// This sets up the adapter to be used by Enzyme
Enzyme.configure({ adapter: new EnzymeAdapter() });

describe('Registration Component', () => {

    it('Test  without throwing an error', () => {
        expect(shallow(< RegistrationComponent />).exists()).toBe(true)
    })

    it('Test an email input', () => {
        expect(shallow(< RegistrationComponent />).find('#firstName').length).toEqual(1)
    })
    it('Test a password input', () => {
        expect(shallow(< RegistrationComponent />).find('#lastName').length).toEqual(1)
    })
    it('Test an email input', () => {
        expect(shallow(< RegistrationComponent />).find('#emailId').length).toEqual(1)
    })
    it('Test a password input', () => {
        expect(shallow(< RegistrationComponent />).find('#password').length).toEqual(1)
    })
    it('Test a password input', () => {
        expect(shallow(< RegistrationComponent />).find('#confirmPassword').length).toEqual(1)
    })
    describe('firstName input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< RegistrationComponent />);
            wrapper.find('#firstName').simulate('change',
                {
                    target: {
                        name: 'firstName',
                        value: 'Sachin'
                    }
                });
            expect(wrapper.state('firstName')).toEqual('Sachin');
        })
    })
    
    
    describe('lastName input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< RegistrationComponent />);
            wrapper.find('#lastName').simulate('change',
                {
                    target: {
                        name: 'lastName',
                        value: 'maurya'
                    }
                });
            expect(wrapper.state('lastName')).toEqual('maurya');
        })
    })
    describe('email input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< RegistrationComponent />);
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
    describe('password input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< RegistrationComponent />);
            wrapper.find('#password').simulate('change',
                {
                    target: {
                        name: 'password',
                        value: '987654321'
                    }
                });
            expect(wrapper.state('password')).toEqual('987654321');
        })
    })
    describe('conform password input', () => {
        it('should respond to change event and change the state of the Login Component', () => {
            const wrapper = shallow(< RegistrationComponent />);
            wrapper.find('#confirmPassword').simulate('change',
                {
                    target: {
                        name: 'confirmPassword',
                        value: '987654321'
                    }
                });
            expect(wrapper.state('confirmPassword')).toEqual('987654321');
        })
    })
})