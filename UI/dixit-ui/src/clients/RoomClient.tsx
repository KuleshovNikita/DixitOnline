export default async function createNewRoomClient(roomCode : string | null) : boolean {
    const result : boolean = 
        await fetch(process.env.REACT_APP_API_URL + 'rooms/newRoom',
        { 
            method: 'POST',
            headers: {
                'Content-Type': "application/json; charset=utf-8"
            },
            body: JSON.stringify(roomCode),
        })
        .then(resp => resp.json())
        .then(res => JSON.parse(res, Boolean))
        .catch(err => console.log(err));
    
    return result;
}