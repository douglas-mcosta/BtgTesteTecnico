import { PedidoItemViewModel } from "./pedido-item.vm";

export class PedidoViewModel {
    id: string;
    clienteId: string;
    codigo: number;
    status: number;
    data: string;
    valorTotal: number;
    itens: PedidoItemViewModel[];
}