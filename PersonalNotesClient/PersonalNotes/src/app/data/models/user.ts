export interface UserCreate{
    name: string,
    password: string
}


export interface UserAuthenticateResponse{
    name: string,
    token: string
}