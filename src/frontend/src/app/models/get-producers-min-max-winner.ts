export type GetProducersMinMaxWinner = {
  min: {
    producer: string;
    interval: number;
    previousYearWin: number;
    follingYearWin: number;
  },
  max: {
    producer: string;
    interval: number;
    previousYearWin: number;
    follingYearWin: number;
  },
};
