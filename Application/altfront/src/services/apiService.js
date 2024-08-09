import axios from 'axios';

const apiUrl = 'http://localhost:5012';

export const registerUser = async (userData) => {
  return axios.post(`${apiUrl}/user`, userData);
};

export const loginUser = async (credentials) => {
  return axios.get(`${apiUrl}/user`, credentials);
};

export const getBoards = async (userData) => {
    return axios.get(`${apiUrl}/board`, userData);
}

// Add other API functions as needed
