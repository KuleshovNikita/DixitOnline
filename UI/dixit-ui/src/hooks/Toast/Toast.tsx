import { toast } from 'react-toastify';
import { ToastType } from '../../models/ToastType';

import 'react-toastify/dist/ReactToastify.css';

export function throwToast(message : string, type : ToastType) {
    toast(message, { type: type });
}