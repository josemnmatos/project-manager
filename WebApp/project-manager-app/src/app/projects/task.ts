export interface Task {
  id: number;
  name: string;
  description: string;
  state: number;
  deadline: Date;
  developerId: number;
}
