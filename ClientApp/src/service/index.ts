import { createAsyncThunk } from '@reduxjs/toolkit'
import { RootState } from '../state'
import { setLoading, setEmployeeList, cancelEditing } from '../state/app'

const serviceUrl = `${process.env.REACT_APP_SERVICE_URL}employees`

export const getEmployees = createAsyncThunk<void, void, { state: RootState }>(
    'getEmployees',
    async (_, thunkAPI) => {
        try {

            thunkAPI.dispatch(setLoading(true))

            fetch(serviceUrl)
                .then(response => response.json())
                .then(data => thunkAPI.dispatch(setEmployeeList(data)));

        } catch (e) {
        } finally {
            thunkAPI.dispatch(setLoading(false))
        }
    }
)

export const submitEmployee = createAsyncThunk<void, void, { state: RootState }>(
    'submitEmployee',
    async (_, thunkAPI) => {
        try {

            thunkAPI.dispatch(setLoading(true))
            const item = thunkAPI.getState().app.item

            const request = item.id === 0 ?
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name: item.name, value: item.value }),
            }
            :
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(item),
            }

            fetch(serviceUrl, request)
                .then(response => response.json())
                .then(data => thunkAPI.dispatch(setEmployeeList(data)));

        } catch (e) {
        } finally {
            thunkAPI.dispatch(setLoading(false))
            thunkAPI.dispatch(cancelEditing())
        }
    }
)

export const deleteEmployee = createAsyncThunk<void, number, { state: RootState }>(
    'deleteEmployee',
    async (id, thunkAPI) => {
        try {

            thunkAPI.dispatch(setLoading(true))

            const delUrl = `${serviceUrl}/${id}`

            const request = {
                method: 'DELETE',
            }

            fetch(delUrl, request)
                .then(response => response.json())
                .then(data => thunkAPI.dispatch(setEmployeeList(data)));

        } catch (e) {
        } finally {
            thunkAPI.dispatch(setLoading(false))
        }
    }
)