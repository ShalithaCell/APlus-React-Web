import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import DashboardIcon from '@material-ui/icons/Dashboard';
import EmojiEventsIcon from '@material-ui/icons/EmojiEvents';
import PeopleIcon from '@material-ui/icons/People';
import EventIcon from '@material-ui/icons/Event';
import EqualizerTwoToneIcon from '@material-ui/icons/EqualizerTwoTone';
import StoreMallDirectoryIcon from '@material-ui/icons/StoreMallDirectory';
import Tooltip from '@material-ui/core/Tooltip';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import EditLocationTwoToneIcon from '@material-ui/icons/EditLocationTwoTone';

export const mainListItems = (
    <div>
        <ListItem button>

            <ListItemIcon>
                <StoreMallDirectoryIcon />
            </ListItemIcon>
            <ListItemText primary="Organization" />

        </ListItem>
        <ListItem button>
            <Tooltip title="Add Branch">
                <ListItemIcon>
                    <AddCircleIcon />
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
            <ListItemIcon>
                <EventIcon />
            </ListItemIcon>
            <ListItemText primary="Month Plan" />

        </ListItem>
        <ListItem button>

            <ListItemIcon>
                <EditLocationTwoToneIcon />
            </ListItemIcon>
            <ListItemText primary="Edit Organization" />

        </ListItem>
    </div>
);

export const secondaryListItems = (
    <div>
        <ListSubheader inset>Comparing Profit</ListSubheader>
        <ListItem button>

            <ListItemIcon>
                <EmojiEventsIcon/>
            </ListItemIcon>
            <ListItemText primary="Best Branch" />

        </ListItem>
        <ListItem button>

            <ListItemIcon>
                <EqualizerTwoToneIcon />
            </ListItemIcon>
            <ListItemText primary="Last week" />

        </ListItem>
        <ListItem button>

            <ListItemIcon>
                <EqualizerTwoToneIcon  />
            </ListItemIcon>
            <ListItemText primary="Current month" />

        </ListItem>
        <ListItem button>

            <ListItemIcon>
                <EqualizerTwoToneIcon  />
            </ListItemIcon>
            <ListItemText primary="Last 6 months" />

        </ListItem>
        <ListItem button>

            <ListItemIcon>
                <EqualizerTwoToneIcon  />
            </ListItemIcon>
            <ListItemText primary="Year end sale" />

        </ListItem>
    </div>
);
