import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import DashboardIcon from '@material-ui/icons/Dashboard';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import PeopleIcon from '@material-ui/icons/People';
import BarChartIcon from '@material-ui/icons/BarChart';
import LayersIcon from '@material-ui/icons/Layers';
import AssignmentIcon from '@material-ui/icons/Assignment';
import Tooltip from '@material-ui/core/Tooltip';

export const mainListItems = (
    <div>
        <ListItem button>
            <Tooltip title="Organization">
                <ListItemIcon>
                    <DashboardIcon />
                </ListItemIcon>
                <ListItemText primary="Organization" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Add Branch">
                <ListItemIcon>
                    <ShoppingCartIcon />
                </ListItemIcon>
            </Tooltip>
            <ListItemText primary="Add Branch" />
        </ListItem>
        <ListItem button>
            
            <Tooltip title="Manage Branch">
                <ListItemIcon>
                    <PeopleIcon />
                </ListItemIcon>
            </Tooltip>
            <ListItemText primary="Manage Branches" />
            
        </ListItem>
        <ListItem button>
            <Tooltip title="Month Plan">
                <ListItemIcon>
                    <BarChartIcon />
                </ListItemIcon>
                <ListItemText primary="Month Plan" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Edit Organization">
                <ListItemIcon>
                    <LayersIcon />
                </ListItemIcon>
                <ListItemText primary="Edit Organization" />
            </Tooltip>
        </ListItem>
    </div>
);

export const secondaryListItems = (
    <div>
        <ListSubheader inset>Comparing Profit</ListSubheader>
        <ListItem button>
            <Tooltip title="Best Branch">
                <ListItemIcon>
                    <AssignmentIcon />
                </ListItemIcon>
                <ListItemText primary="Best Branch" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Last week">
                <ListItemIcon>
                    <AssignmentIcon />
                </ListItemIcon>
                <ListItemText primary="Last week" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Current month">
                <ListItemIcon>
                    <AssignmentIcon />
                </ListItemIcon>
                <ListItemText primary="Current month" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Last 6 months">
                <ListItemIcon>
                    <AssignmentIcon />
                </ListItemIcon>
                <ListItemText primary="Last 6 months" />
            </Tooltip>
        </ListItem>
        <ListItem button>
            <Tooltip title="Year end sale">
                <ListItemIcon>
                    <AssignmentIcon />
                </ListItemIcon>
                <ListItemText primary="Year end sale" />
            </Tooltip>
        </ListItem>
    </div>
);