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