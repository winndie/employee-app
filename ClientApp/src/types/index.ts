export interface IEmployee {
    id: number,
    name: string,
    value: number
}

export interface IGetEmployeeResponse {
    employees: IEmployee[],
    sum: number,
    pageSize: number,
    lastPage: number,
    isDisplaySum: boolean
}