import React, { useEffect, useState } from 'react';
import { Project } from '../../types/project';
import { projectApi } from '../../services/project-api';
import './CreateProjectModal.css';
import { useForm } from 'react-hook-form';
import { clientApi } from '../../services/client-api';
import { Client } from '../../types/client';

interface CreateProjectModalProps {
  isOpen: boolean;
  onClose: () => void;
}

type FormValues = {
  projectName: string;
  clientName: string;
  manager: string;
};

const CreateProjectModal: React.FC<CreateProjectModalProps> = ({
  isOpen,
  onClose,
}) => {
  const { register, handleSubmit, reset } = useForm<FormValues>();
  const [clients, setClients] = useState<Client[]>([]);
  
  useEffect(() => {
    const fetchClients = async () => {
      try {
        const clientData = await clientApi.getAllClients();
        setClients(clientData);
      } catch (error) {
        console.error('Failed to fetch clients:', error);
      }
    };

    fetchClients();
  }, []);
  
  const onSubmit = async (data: FormValues) => {
    await projectApi.createProject(data);

    reset();

    alert(JSON.stringify(data));

    onClose();
  };

  if (!isOpen) return null;

  return (
    <div className="modal-backdrop">
      <div className="modal-content">
        <div className="modal-header">
          <h3>Create New Project</h3>
          <button className="close-button" onClick={onClose}>&times;</button>
        </div>
        <form onSubmit={handleSubmit(onSubmit)}>

        <div className="form-group">
            <label htmlFor="projectName">Project Name</label>
            <input 
              id="projectName"
              {...register("projectName")} 
              placeholder="Enter project name" 
            />
          </div>

          <div className="form-group">
            <label htmlFor="manager">Project Manager</label>
            <input 
              id="manager"
              {...register("manager")} 
              placeholder="Enter manager name" 
            />
          </div>

          <div className="form-group">
            <label htmlFor="clientName">Client Name</label>
            <select id="clientName" {...register("clientName")}>
              <option value="A">Client A</option>
              <option value="B">Client B</option>
              <option value="C">Client C</option>
              {clients.map((client) => (
              <option key={client.id} value={client.id}>
                {client.name}
              </option>
            ))}
            </select>
          </div>

          <button type="submit" className="submit-button">
            Create Project
          </button>
        </form>
      </div>
    </div>
  );
};

export default CreateProjectModal;