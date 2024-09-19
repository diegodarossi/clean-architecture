import React, { useEffect, useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import kendoka from './kendoka.svg';
import { Grid, GridColumn, GridToolbar } from '@progress/kendo-react-grid';
import Axios from "axios";
import { toDataSourceRequest, toDataSourceRequestString, translateDataSourceResultGroups } from '@progress/kendo-data-query';
import { mapTree } from "@progress/kendo-react-treelist";

function GridTeste() {
    const [data, setData] = useState([] as any[]);
    const [dataState, setDataState] = useState({ take: 5, skip: 0, group: [] })
    const [total, setTotal] = useState(0);

    // Check if the Grid is grouped.
    const hasGroups = dataState.group && dataState.group.length;

    // Make request to the server for server side data operations.
    useEffect(() => {
        Axios.post("https://localhost:5001/api/WeatherForecasts/teste", toDataSourceRequest(dataState)).then((response) => {
            let parsedDataNew = mapTree(response.data.data, 'items', (product) => {
                product.created = product.created !== null ? new Date(product.created) : null;
                return product
            })

            parsedDataNew = hasGroups ? translateDataSourceResultGroups(parsedDataNew) : parsedDataNew
            setTotal(response.data.total)
            setData([...parsedDataNew]);
        });
    }, [dataState])

    const handleDataStateChange = (event: any) => {
        setDataState(event.dataState);
    }

  return (
      <Grid
          style={{
              height: "520px",
          }}
          data={data}
          {...dataState}
          pageable
          sortable
          filterable
          groupable
          total={total}
          onDataStateChange={handleDataStateChange}
      >
          <GridToolbar>
              <div>
                  <Button
                      title="Add new"
                      themeColor="primary"
                  >
                      Add new
                  </Button>
              </div>
          </GridToolbar>
          <GridColumn field="listId" title="Id" width="100px" editable={false} filterable={false} />
          <GridColumn field="title" title="Titulo" />
          <GridColumn field="note" title="Nota" />
          <GridColumn field="created" title="Data de inclusao" filter='date' format={'{0:dd/MM/yyyy HH:mm}'} />
      </Grid>
  );
}

export default GridTeste;
