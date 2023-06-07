import React, { Component } from 'react';

export class PlayerCreation extends Component {
    static displayName = PlayerCreation.name;

    constructor(props) {
        super(props);
        this.state = { message: ''};
    }

    onCreatePlayer = () => {
        let playerInfo = {
            Name: this.refs.Name.value
        };

        fetch('https://localhost:44462/player', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(playerInfo)
        }).then(r => r.json()).then(response => {
            if (response) {
                this.setState({ message: 'Player Created' });
            }
        });
    }

    render() {
        return (
            <div>
                <h2>Create a player</h2>
                <p>
                    <label>Player Name <input type="text" ref="Name"></input></label>
                </p>
                <button onClick={this.onCreatePlayer}>Create</button>
                <p>{this.state.message}</p>
            </div>
        )
    }
}
