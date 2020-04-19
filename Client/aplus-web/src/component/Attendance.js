import React, { useStyles, useEffect } from 'react';
import MaterialTable from 'material-table';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Navbar from './navbar';
import { GetSession } from '../services/sessionManagement';
import { decrypt } from '../services/EncryptionService';
import axios from 'axios';
import { ADD_ATTENDANCE } from '../config';
import { useDispatch } from 'react-redux';
import { makeStyles } from "@material-ui/styles";

export default function Attendance() {
  const dispatch = useDispatch();
  const [ state, setState ] = React.useState({
    columns : [
      { title: 'Name', field: 'name' },
      { title  : 'Date',
       field  : 'date',
      lookup : { 34: '2020/04/10', 63: '2020/04/11', 60: '2020/04/12', 62: '2020/04/13'   }
      }, 
      { title  : 'Clock on Time', 
      field  : 'ClockonTime', 
      lookup : { 34: '8.00am', 63: '8.05am' }
      },
      { title  : 'Clock out Time',
        field  : 'ClockoutTime', 
        lookup : { 34: '5.00pm', 63: '5.05pm' }
      },
      {
        title : ' Working Hours',
        field : 'hours'
       
      }
    ],
    data : []

  });
  async function AddAttendance()
  {
      const localData = JSON.parse(GetSession());
      let token = localData.sessionData.token;
      token = decrypt(token);

      //console.log('ABC');
      let success = false;
      let resData;

      console.log(token);

      const userObj = {
        description : state.columns
      }

      //API call
      await axios({
        method  : 'post',
        url     : ADD_ATTENDANCE,
        headers : { Authorization: 'Bearer ' + token },
        data    : userObj
    })
        .then(function(response)
        {
            console.log("ok");
        })
        .catch(function(error)
        {
            if(error.response.status === 401){
                dispatch({
                    type    : SET_SESSION_EXPIRED,
                    payload : true
                });

            }
            throw error;
        });
}

  return (
      <Container component="main" maxWidth="sx">
          <Navbar/> 
    
          <Container  maxWidth="s">
              <Typography component="div" style={ {   height: '15vh' } } />
              <MaterialTable
      title="Attendance Sheet"
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