import axios from 'axios'
const baseURL="https://localhost:44349/api/"
export function createNotes (data){
    return axios.post (baseURL+'notes/Add', data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function GetAllNotes (){
    return axios.get (baseURL+'notes/Show',{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function SetReminder (data){
    return axios.post (baseURL+'notes/Reminder',data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function Archive (data){
    return axios.post (baseURL+'notes/Archive',data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function DeleteNote (data){
    return axios.post (baseURL+'notes/Trash',data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}