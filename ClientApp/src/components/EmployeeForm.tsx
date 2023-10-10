import React from 'react'
import { useSelector } from 'react-redux'
import { Form } from 'reactstrap'
import '../index.css'
import { RootState, useAppDispatch } from '../state'
import { updateEmployee, cancelEditing } from '../state/app'
import { submitEmployee } from '../service'

const EmployeeForm = () => {

    const editing = useSelector((state: RootState) => state.app.editing)
    const item = useSelector((state: RootState) => state.app.item)
    const dispatch = useAppDispatch()

    return (
        editing ?
            <>
                <Form className="form-group p-2 flex-wrap">
                    <div className="row">
                        <div className="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                            <label htmlFor="title">Name</label>
                        </div>
                        <div className="col-sm-10 col-md-10 col-lg-10 col-xl-10">
                            <input type='string' maxLength={100} value={item.name}
                                onChange={(e) => dispatch(updateEmployee({ key: 'name', value: e.currentTarget.value }))} className="form-control" id="name" aria-describedby="name" placeholder="Name of Employee" />
                            <small id="nameHelp" className="form-text text-muted">What is the name of the employee?</small>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                            <label htmlFor="title">Value</label>
                        </div>
                        <div className="col-sm-10 col-md-10 col-lg-10 col-xl-10">
                            <input type='number' value={item.value}
                                onChange={(e) => dispatch(updateEmployee({ key: 'value', value: e.currentTarget.value }))} className="form-control" id="value" aria-describedby="value" placeholder="Value of Employee" />
                            <small id="valueHelp" className="form-text text-muted">What is the value of the employee?</small>
                        </div>
                    </div>
                    <div className="row p-2">
                        <div className="p-1"><button type="submit" onClick={(e) => {
                            e.preventDefault()
                            dispatch(submitEmployee())
                        }} className="btn btn-primary">Submit</button></div>
                        <div className="p-1"><button type="submit" onClick={(e) => {
                            e.preventDefault()
                            dispatch(cancelEditing())
                        }} className="btn btn-primary">Cancel</button></div>
                    </div>
                </Form>
            </>
            : <></>
    )
}

export default EmployeeForm