import axios from 'axios'
const baseURL="https://localhost:44349/api/"
// import axios from 'axios';

export function registration (data){
    return axios.post (baseURL+'account/Add', data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function login (data){
    return axios.post (baseURL+'account/Login', data,{
            headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function facebookLogin (data){
    return axios.post (baseURL+'account/FacebookLogin', data,{
            headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}

export function googleLogin (data){
    return axios.post (baseURL+'account/SocialLogin', data,{
            headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}

export function forgot (data){
    return axios.post (baseURL+'account/Forgot', data,{
            headers:{
            "Authorization" : 'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function reset (data){
    return axios.put (baseURL+'account/Reset', data,{
            headers:{
            "Authorization" : 'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function getUser()
{
    return axios.get(baseURL+'account/reg',{
        headers:{
        "Authorization" : 'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}