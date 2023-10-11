import React from 'react'
import { useSelector } from 'react-redux'
import { Table, Pagination, PaginationLink } from 'reactstrap'
import '../index.css'
import { RootState, useAppDispatch } from '../state'
import { setFirstPage, setPrevPage, setNextPage, setLastPage, viewEmployee } from '../state/app'
import { deleteEmployee } from '../service'

const EmployeeTable: React.FC = () => {

    const editing = useSelector((state: RootState) => state.app.editing)
    const list = useSelector((state: RootState) =>
        state.app.list
            .filter(x => x.id !== state.app.item.id)
            .slice((state.app.currentPage - 1) * state.app.pageSize, state.app.currentPage * state.app.pageSize)
    )
    const dispatch = useAppDispatch()

    return (
        <div className="p-2 table-responsive-lg table-responsive-xl table-responsive-md table-responsive-sm">
            <Table className="table" bordered hover>
                <thead><tr>
                    <th scope="col">#</th>
                    <th scope="col">Name</th>
                    <th scope="col">Value</th>
                    {editing ? <></> :<th scope="col">Actions</th>}
                </tr></thead>
                <tbody>
                    {list.length === 0 ? <tr><td>No record found</td></tr> :
                        list.map((x, i) => (
                            <tr key={i}>
                                <th className='align-middle'>{x.id}</th>
                                <td className='align-middle'>{x.name}</td>
                                <td className='align-middle'>{x.value}</td>
                                {editing ? <></> :
                                    <td><div className='form-row'>
                                <div className="p-1">
                                    <button onClick={e => {
                                        e.preventDefault()
                                        dispatch(viewEmployee(x))
                                    }} type="submit" className="btn btn-primary">Edit</button>
                                </div>
                                <div className="p-1">
                                    <button onClick={e => {
                                        e.preventDefault()
                                        dispatch(deleteEmployee(x.id))
                                    }} type="submit" className="btn btn-primary">Delete</button>
                                </div>                                        
                                </div></td>}
                        </tr>))}
                </tbody>
            </Table>
            <Pagination>
                <PaginationLink first href="#" onClick={() => dispatch(setFirstPage())} />
                <PaginationLink previous href="#" onClick={() => dispatch(setPrevPage())} />
                <PaginationLink next href="#" onClick={() => dispatch(setNextPage())} />
                <PaginationLink last href="#" onClick={() => dispatch(setLastPage())} />
            </Pagination>
        </div>
    )

}

export default EmployeeTable