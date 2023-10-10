import React from 'react'
import { Button, Card, CardText, CardTitle } from 'reactstrap'
import '../index.css'
import { useSelector } from 'react-redux'
import { RootState, useAppDispatch } from '../state'
import { newEmployee } from '../state/app'

const EmployeeHeader: React.FC = () => {

    const dispatch = useAppDispatch()
    const { editing, sum } = useSelector((state: RootState) => state.app)

    return (
        editing?<></> :
            <Card body className="text-center">
                {sum ? <>
                    <CardTitle tag="h5">
                Sum of employees' value
            </CardTitle>
            <CardText>
                {sum}
            </CardText>
          </>: <></>}
          <Button className="btn btn-primary" onClick={() => dispatch(newEmployee())} type="submit">
            Add Employee
          </Button>
          </Card>
    )
}

export default EmployeeHeader