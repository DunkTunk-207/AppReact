import React from 'react';
import ProjectTable from '../components/ProjectTable/ProjectTable';

const Projects: React.FC = () => {
  return (
    <div className="page-content">
      <h1>All Projects</h1>
      <ProjectTable />
    </div>
  );
};

export default Projects;