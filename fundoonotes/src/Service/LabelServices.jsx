import axios from 'axios'
const baseURL="https://localhost:44349/api/"
// import axios from 'axios';

export function getLabel (){
    return axios.get (baseURL+'label/LabelShow',{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function CreateLabel (data){
    return axios.post (baseURL+'label/AddLabel',data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function DeleteLabel (data){
    return axios.delete (baseURL+'label/LabelDelete?label='+data,{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}
export function RenameLabel (data,id){
    return axios.put (baseURL+'label/LabelUpdate?label='+data+'&id='+id,"",{
        headers:{
            
            "Authorization" :  'Bearer '+localStorage.getItem('FundooUserToken')
        }
    })
}