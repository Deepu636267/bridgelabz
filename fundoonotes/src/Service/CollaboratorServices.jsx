import axios from 'axios'
const baseURL="https://localhost:44349/api/"
export function createNotes (data){
    return axios.post (baseURL+'Collaborators/Add', data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function removeCollaborators (data){
    console.log("ghjfd",data)
    return axios.post (baseURL+'Collaborators/Remove', data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}