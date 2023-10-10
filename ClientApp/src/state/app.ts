import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { IEmployee, IGetEmployeeResponse } from '../types'

export const appSlice = createSlice({
    name: 'app',
    initialState: {
        loading: true as boolean,
        editing: false as boolean,
        list: [] as IEmployee[],
        item: {id:0} as IEmployee,
        sum: undefined as undefined | number,
        currentPage: 1 as number,
        pageSize: 5 as number,
        lastPage: 0 as number,
    },
    reducers: {
        setLoading: (state, action: PayloadAction<boolean>) => {
            state.loading = action.payload
        },
        cancelEditing: (state) => {
            state.editing = false
            state.item = {} as IEmployee
        },
        setEmployeeList: (state, action: PayloadAction<IGetEmployeeResponse>) => {
            state.list = action.payload.employees
            state.pageSize = action.payload.pageSize
            state.lastPage = action.payload.lastPage
            state.sum = action.payload.isDisplaySum ? action.payload.sum : undefined
        },
        updateEmployee: (state, action: PayloadAction<{ key: keyof IEmployee, value: string | number }>) => {
            state.item = { ...state.item, [action.payload.key]: action.payload.value } as IEmployee
        },
        newEmployee: (state) => {
            state.editing = true
            state.item = { id: 0, name: '', value:0 } as IEmployee
        },      
        viewEmployee: (state, action: PayloadAction<IEmployee>) => {
            state.editing = true
            state.item = action.payload
        },      
        setFirstPage: (state) => {
            state.currentPage = 1
        },
        setPrevPage: (state) => {
            const newPage = state.currentPage - 1
            state.currentPage = newPage < 1 ? 1 : newPage 
        },
        setNextPage: (state) => {
            const newPage = state.currentPage + 1
            state.currentPage = newPage > Math.ceil(state.list.length / state.pageSize) ? Math.ceil(state.list.length / state.pageSize) : newPage
        },
        setLastPage: (state) => {
            state.currentPage = Math.ceil(state.list.length / state.pageSize)
        },
    },
})

export const {
    setLoading,
    cancelEditing,
    setEmployeeList,
    updateEmployee,
    newEmployee,
    viewEmployee,
    setFirstPage,
    setPrevPage,
    setNextPage,
    setLastPage
} = appSlice.actions
