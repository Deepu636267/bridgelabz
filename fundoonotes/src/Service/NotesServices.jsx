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
export function DeleteForever (data){
    return axios.post (baseURL+'notes/Delete',data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function DeleteAll (){
    return axios.delete (baseURL+'notes/DeleteAll',{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function RemoveRminder (data){
    return axios.post (baseURL+'notes/RemoveReminder',data,{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function UpdateNotes (data){
    return axios.put (baseURL+'notes/Update',data,{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function SetColor (data){
    return axios.post (baseURL+'notes/SetColor',data,{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function SetPin (data){
    return axios.post (baseURL+'notes/Pin?Id='+data,"",{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function SetUnPin (data){
    return axios.post (baseURL+'notes/UnPin?Id='+data,"",{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function BulkDelete (data){
    console.log("dbfdhgf",data)
    return axios.post (baseURL+'notes/TrashSelected',data,{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function ImageUpload (data,Id){
    console.log("dbfdhgf",data)
    return axios.post (baseURL+'notes/Image?Id='+Id,data,{
        headers:{
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}

