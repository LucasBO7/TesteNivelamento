import axios from "axios";

const apiPort: string = '7034';
const apiDomain: string = 'localhost';

const apiUrl: string = `https://${apiDomain}:${apiPort}/`;

const api = axios.create({
    baseURL: apiUrl
});

export default api;