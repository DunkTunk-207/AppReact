import { Project } from '../types/project';

const API_BASE_URL = 'http://localhost:5096/api'; // Thay đổi URL API của bạn

export const projectApi = {
    getAllProjects: async (): Promise<Project[]> => {
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
    },

    getProjectById: async (id: number): Promise<Project> => {
      try {
        const response = await fetch(`${API_BASE_URL}/projects/${id}`);
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        return data;
      } catch (error) {
        console.error('Error fetching project by id:', error);
        throw error;
      }
    },

    createProject: async (project: Partial<Project>): Promise<Project> => {
      try {
        const response = await fetch(`${API_BASE_URL}/projects`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(project)
        });
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        return data;
      } catch (error) {
        console.error('Error creating project:', error);
        throw error;
      }
    },
  
    getProjectsWithParams: async (
      page: number = 1, 
      limit: number = 10,
      sortField?: string,
      sortOrder?: 'asc' | 'desc'
    ): Promise<{ data: Project[], total: number }> => {
      try {
        const params = new URLSearchParams({
          page: page.toString(),
          limit: limit.toString(),
          ...(sortField && { sort: sortField }),
          ...(sortOrder && { order: sortOrder })
        });
  
        const response = await fetch(`${API_BASE_URL}/projects?${params}`);
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
  
        const data = await response.json();
        return data;
      } catch (error) {
        console.error('Error fetching projects with params:', error);
        throw error;
      }
    }
  };