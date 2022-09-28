export default interface ServerResult {
    isSuccessful: boolean,
    clientErrorMessage: string
};

export interface DataServerResult extends ServerResult {
    value: any
}