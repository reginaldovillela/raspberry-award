export type GetMoviesData = {
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  totalRecords: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
  items: {
    id: string;
    title: string;
    year: number;
    winner: boolean;
  }[];
};
