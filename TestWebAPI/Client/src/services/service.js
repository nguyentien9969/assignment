import httpClient from "../httpClient/httpClient"
import { END_POINT } from "../httpClient/config"

export const loginService = ()=>{
    return httpClient.post(END_POINT.login)
}
export const profileService = (id)=>{
    return httpClient.get(`${END_POINT.user}/${id}`)
}

export const getBook = (id)=>{
    return httpClient.get(`${END_POINT.book}/${id}`)
}

export const deleteBook = (id) =>{
    return httpClient.delete(`${END_POINT.book}/${id}`)
}

export const editBook = (value) => {
    return httpClient.put(END_POINT.book,value)
}

export const addBook = (value) => {
    return httpClient.post(END_POINT.book,value)
}