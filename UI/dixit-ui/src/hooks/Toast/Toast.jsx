import { toast } from 'react-toastify';

import 'react-toastify/dist/ReactToastify.css';

export function throwToast(message, type) {
    toast(message, { type: type });
}