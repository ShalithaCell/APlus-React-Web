import * as React from 'react';
import Paper from '@material-ui/core/Paper';
import {
	Chart,
	PieSeries,
	Title
} from '@devexpress/dx-react-chart-material-ui';

import { Animation } from '@devexpress/dx-react-chart';
import Navbar from '../navbar';
import Container from '@material-ui/core/Container';

const data = [
	{ country: 'Russia', area: 12 },
	{ country: 'Canada', area: 7 },
	{ country: 'USA', area: 7 },
	{ country: 'China', area: 7 },
	{ country: 'Brazil', area: 6 },
	{ country: 'Australia', area: 5 },
	{ country: 'India', area: 2 },
	{ country: 'Others', area: 55 }
];
export default class storepie extends React.PureComponent {

	constructor(props) {
		super(props);

		this.state = {
			data
		};
	}

	render() {

		const { data: chartData } = this.state;

		return (
    <div>
        <Navbar/>
        <div className={ 'top-5pres' }>
            <Container fixed>
                <Paper>
                    <Chart
					data={ chartData }
				>
                        <PieSeries
						valueField="area"
						argumentField="country"
					/>
                        <Title
						text="Monthly profit"
					/>
                        <Animation />
                    </Chart>
                </Paper>
            </Container>
        </div></div>
			
		);
	}
}