import React from 'react';
import './App.css';
import './css-common/InputField.css';
import './css-common/Button.css';
import PopUpMessage from './components/PopUpMessage/PopUpMessage';

function App() {
  const [playerName, setPlayerName] = React.useState('');
  const [isError, setIsError] = React.useState(false);

  return (
    <div className="App">
        <h1>Dixit Online</h1>
        <input className="InputField" placeholder='Enter your name' type={"text"} onChange={handleChange}/>
        <button className='Button' onClick={registerNewPlayer}>Start New Game</button> 
        <button className='Button' >Connect To The Room</button> 
        { isError && <PopUpMessage message="Name cannot be empty!" type='error' showMessage={() => showPopup(false)}/> }
    </div>
  );

  function showPopup(toggle) {
    setIsError(toggle);
  }

  function handleChange(event) {
    setPlayerName(event.target.value);
  }

  function registerNewPlayer(event) {
    if(playerName === '') {
      setIsError(true);
    }

    var player = {Name: playerName, PlayerId: 1};

    fetch('https://localhost:44303/players/newPlayer',
    { method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': "application/json;charset=utf-8"
      },
      body: JSON.stringify(player),
    }).catch(err => console.log(err));

    event.preventDefault();
  }
}

export default App;
