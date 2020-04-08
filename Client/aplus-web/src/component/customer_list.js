import React from 'react';
import MaterialTable from 'material-table';

export default function customer_list() {
  const [ state, setState ] = React.useState({
    columns : [
      { title: 'Frist Name', field: 'fname' },
      { title: 'Last Name', field: 'lname' },
      { title: 'E-mail', field: 'email', type: 'email' },
      { title: 'ID Number', field: 'idnumber' },
      { title: 'Phone number', field: 'phone_number' },
      { title: 'No of Point', field: 'num_of_point' }
    
    ]
    
  });

  return (
      <MaterialTable
      title="Customer list"
      columns={ state.columns }
      data={ state.data }
      editable={ {
        onRowAdd : (newData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              setState((prevState) => {
                const data = [ ...prevState.data ];
                data.push(newData);
                return { ...prevState, data };
              });
            }, 600);
          }),
        onRowUpdate : (newData, oldData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              if (oldData) {
                setState((prevState) => {
                  const data = [ ...prevState.data ];
                  data[ data.indexOf(oldData) ] = newData;
                  return { ...prevState, data };
                });
              }
            }, 600);
          }),
        onRowDelete : (oldData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              setState((prevState) => {
                const data = [ ...prevState.data ];
                data.splice(data.indexOf(oldData), 1);
                return { ...prevState, data };
              });
            }, 600);
          })
      } }
    />
  );
}