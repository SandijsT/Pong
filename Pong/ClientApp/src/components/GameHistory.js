import React, { Component } from 'react';

export class GameHistory extends Component {
  static displayName = GameHistory.name;

  constructor(props) {
    super(props);
    this.state = { game: [], loading: true };
  }

  componentDidMount() {
    this.populateGameData();
  }

  static renderGameTable(games) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Challanger</th>
            <th>Opponent</th>
            <th>Winner</th>
          </tr>
        </thead>
        <tbody>
          {games.map(game =>
            <tr key={game.date}>
                <td>{game.date}</td>
                <td>{game.challanger}</td>
                <td>{game.opponent}</td>
                <td>{game.winner}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : GameHistory.renderGameTable(this.state.game);

    return (
      <div>
        <h1 id="tabelLabel" >Games</h1>
        <p>History of played games.</p>
        {contents}
      </div>
    );
  }

  async populateGameData() {
    const response = await fetch('game');
    const data = await response.json();
    this.setState({ game: data, loading: false });
  }
}
