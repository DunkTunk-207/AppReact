import React, { useEffect, useState } from 'react';
import { Project } from '../../types/project';
import { projectApi } from '../../services/project-api';
import './ProjectTable.css';
import { data } from 'react-router-dom';

const ProjectTable: React.FC = () => {
  const [projects, setProjects] = useState<Project[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchDataProjects();
  }, []);

  const fetchDataProjects = async () => {
    try {
      const data = await projectApi.getAllProjects();
      setProjects(data);
    } catch (error) {
      console.error('Error fetching projects:', error);
    } finally {
      setLoading(false);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="table-responsive">
      <table className="table table-hover">
        <thead className="table-dark">
          <tr>
            <th>PROJECT NAME</th>
            <th>Est. Start Date</th>
            <th>Est. End Date</th>
            <th>Duration</th>
            <th>Client</th>
            <th>Contact</th>
            <th>Project Manager</th>
            <th>Project Director</th>
            <th>Currency</th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <tr key={project.id}>
              <td>{project.name}</td>
              <td>{project.startDate}</td>
              <td>{project.endDate}</td>
              <td>{project.duration}</td>
              <td>{project.client?.name}</td>
              <td>{project.client?.contact}</td>
              <td>{project.manager}</td>
              <td>{project.director}</td>
              <td>{project.currency}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProjectTable;