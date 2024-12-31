export interface Project {
  id: string;
  name: string;
  manager: string;
  director: string;
  startDate: string;
  endDate: string;
  duration: string;
  currency: string;
  client?:
  {
    name: string;
    contact?: string;
  };
  contact?: string;
  clientId: number;
}