package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class KlientUsluga {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Klient klient;

    @ManyToOne
    private Usluga usluga;

    // Data powiązania klienta z usługą, jeśli potrzebne

    // Getters and Setters
}
