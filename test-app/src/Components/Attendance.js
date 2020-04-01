import React from "react";
import DataTable from 'react-data-table-component';

{/* FAKE DATA TO BE DELETED */}
const data = [{ id: 1, date: '1/1/3030', time: '8:30' }, { id: 2, date: '1/2/3030', time: '10:30' } ];
const columns = [
  {
    name: 'Date',
    selector: 'date',
    sortable: true,
  },
  {
    name: 'Time',
    selector: 'time',
    sortable: true,
    right: true,
  },
];
{/* FAKE DATA TO BE DELETED above */}



export default class Attendance extends React.Component {

    render(){
        return(
            <div>
               <h3> Attendance</h3>
                <DataTable
                    className="Attendance_wrapper"
                    columns={columns}
                    data={data}
                    noHeader 
                    striped
                                 
                 />
            </div>
            
        );
    }
}