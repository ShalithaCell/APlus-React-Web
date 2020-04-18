import React from 'react';
import MaterialTable from 'material-table';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Navbar from './navbar';

export default function AbsentAttendance() {
  const [ state, setState ] = React.useState({
    columns : [
      { title: 'Name', field: 'name' },
      { title: 'Date', field: 'date' },
      { title: 'Status', field: 'status' }
      
    ]
    
  });

  return (
      <Container component="main" maxWidth="sx">
          <Navbar/> 
    
          <Container  maxWidth="s">
              <Typography component="div" style={ {   height: '15vh' } } />
              <MaterialTable
      title="Absent Sheet"
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
          </Container>
      </Container>
  );
}