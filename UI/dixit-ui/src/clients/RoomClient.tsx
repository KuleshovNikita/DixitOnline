export default function createNewRoomClient(roomCode : string | null) {
    fetch(process.env.REACT_APP_API_URL + 'rooms/newRoom',
    { 
        method: 'POST',
        headers: {
            'Content-Type': "application/json; charset=utf-8"
        },
        body: JSON.stringify(roomCode),
    })
    .catch(err => console.log(err));
}