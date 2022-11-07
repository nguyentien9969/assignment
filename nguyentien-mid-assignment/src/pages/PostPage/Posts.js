import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Table, Typography, DeleteOutline, EditOutlined } from 'antd'
import 'antd/dist/antd.css'
const Posts = () => {
  const [persons, setPerson] = useState([])

  useEffect(() => {
    axios
      .get(`https://localhost:7293/Rookies`)
      .then((res) => setPerson(res.data))
      .catch(() => {
        console.log('Error')
      })
  }, [])

  // const persons.isGraduated.toString();
  const data = persons
  console.log(data)
  const columns = [
    {
      title: 'Name',
      dataIndex: 'fullName',
      key: 'id',
    },
    {
      title: 'Gender',
      dataIndex: 'gender',
      key: 'id',
    },
    {
      title: 'Date Of Birth',
      dataIndex: 'dateOfBirth',
      key: 'id',
      render: (_, record) => (
        <Typography>{record.dateOfBirth.slice(0, 10)}</Typography>
      ),
    },
    {
      title: 'Age',
      dataIndex: 'age',
      key: 'id',
    },
    {
      title: 'Birth Place',
      dataIndex: 'birthPlace',
      key: 'id',
    },
    {
      title: 'Action',
      key: '5',
      render: (record) => {
        return (
          <>
            <EditOutlined />
            <DeleteOutline
              onclick={onDeleteStudent(record)}
              style={{ style: 'red', marginLeft: '10px' }}
            />
          </>
        )
      },
    },
  ]

  const onDeleteStudent = () => {
    setPerson((pre) => {
      pre.filter((student) => student.id != record.id)
    })
  }

  return (
    <div class="container">
      <Table dataSource={data} columns={columns} />
    </div>
  )
}

export default Posts
