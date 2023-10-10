import React, { useEffect } from 'react'
import { useSelector } from 'react-redux'
import { Container, Spinner } from 'reactstrap'
import './index.css'
import { RootState, useAppDispatch } from './state'
import { getEmployees } from './service'
import EmployeeHeader from './components/EmployeeHeader'
import EmployeeForm from './components/EmployeeForm'
import EmployeeTable from './components/EmployeeTable'

const App: React.FC = () => {

    const dispatch = useAppDispatch()
    const { loading } = useSelector((state: RootState) => state.app)

    useEffect(() => {
        dispatch(getEmployees())
    },[dispatch])

    return (
        loading ? <Spinner/> :
            <Container className='container'>
                <EmployeeHeader />
                <EmployeeForm />
                <EmployeeTable />
            </Container>
    )
}

export default App