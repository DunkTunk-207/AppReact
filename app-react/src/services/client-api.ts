import { Client } from '../types/client';

const API_BASE_URL = 'http://localhost:5096/api'; // Thay đổi URL API của bạn

export const clientApi = {
    getAllClients: async (): Promise<Client[]> => {
      try {
        const response = await fetch(`${API_BASE_URL}/projects`);
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        return data;
      } catch (error) {
        console.error('Error fetching projects:', error);
        throw error;
      }
    }
  };