import { User, Experience } from "./types/types";


const BACKEND_URL = import.meta.env.VITE_BACKEND_URL;
const API_KEY = import.meta.env.VITE_BACKEND_API_KEY;

export const fetchUsers = async (): Promise<User[]> => {
  try {
    const response = await fetch(`${BACKEND_URL}/users`, { headers: {
      "X-Frontend-Api-Key": API_KEY,
      "content-type": "application/json"
    }, });
    
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    
    return await response.json();
  } catch (error) {
    console.error('Error fetching users:', error);
    throw error;
  }
};

export const fetchExperiences = async (): Promise<Experience[]> => {
  try {
    const response = await fetch(`${BACKEND_URL}/experiences`, { headers: {
      "X-Frontend-Api-Key": API_KEY, "content-type": "application/json"
    }});
    
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    
    return await response.json();
  } catch (error) {
    console.error('Error fetching experiences:', error);
    throw error;
  }
};
